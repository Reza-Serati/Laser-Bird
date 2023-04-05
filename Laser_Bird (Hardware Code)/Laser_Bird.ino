#include "EEPROM.h"
#include "mytimer.h"
#include <AltSoftSerial.h>

#define max_tilt_degree  125   // 55 *2   min: -36  max: +26
#define max_pan_degree   700  // 350*2

#define right_relay_pin 6
#define left_relay_pin  5
#define up_relay_pin    4
#define down_relay_pin  3

#define safty_pin       7
#define laserPin        2
  
#define up_limit     12
#define down_limit   11
#define right_limit  9
#define left_limit   10


int up_down_callibrate = 0;
int right_left_callibrate = 0;

uint32_t start_up_down_callibrate;
uint32_t end_up_down_callibrate;
uint32_t start_right_left_callibrate;
uint32_t end_right_left_callibrate;

uint32_t max_tilt_time = 37000000;
uint32_t max_pan_time = 35000000;

int counter_for_callibrate_interval = 0;
#define callibrate_interval 10
uint32_t time_for_each_pan_degree  = round(max_pan_time   / max_pan_degree);
uint32_t time_for_each_tilt_degree = round(max_tilt_time  / max_tilt_degree);

int laserState = LOW;


boolean stay_called = false;
uint32_t end_pan_time = 0;
uint32_t start_tilt_time = 0;
uint32_t end_tilt_time = 0;
uint32_t start_pan_time = 0;
int pan_position = 0;
int tilt_position = 0;

uint32_t myMicros = 0;

boolean autoMode = false;

struct EEpromPreset {
  byte enable;
  unsigned int panStart;
  unsigned int panEnd;
  byte tiltStart;
  byte tiltEnd;
  byte waitTime;
  byte laserOn;
  byte panTiltRandomState;
};
struct RamPreset {
  unsigned int panStart;
  byte tiltStart;
  byte waitTime;
  byte laserOn;
};
struct pan_tilt_struct {
  int pan;
  int tilt;
};

byte presetCount = 0;
RamPreset autoPresets[100];
pan_tilt_struct array_[100];

byte presetId = 0;


int up_down_dir = 2, left_right_dir = 2;
int buffer_up_down_dir = 0, buffer_left_right_dir = 0;
boolean tilt_moving = true, pan_moving = true;

MyTimer go_pan_timer;
MyTimer go_tilt_timer;
MyTimer pan_timer;
MyTimer tilt_timer;
MyTimer update_tilt_pan_value_timer;

boolean go_next_preset = false;
boolean reset_called = false;
boolean callibrate_called = false;

int counter = 0;
long ttmp = 0, ptmp = 0;
int cali_tmp = 0;

AltSoftSerial pan_tilt_serial;

int l_r_limit_statue = -1;
int u_d_limit_statue = -1;


void setup() {
  randomSeed(analogRead(0));
  Serial.begin(9600);

  for (int i=2; i<=8; i++)
    pinMode(i, OUTPUT); 
  for (int i=8; i<=13; i++)
    pinMode(i, INPUT); 
  for (int i=2; i<=8; i++)
    digitalWrite(i, HIGH);


  digitalWrite(laserPin, LOW);
  digitalWrite(safty_pin, LOW);
  loadPresets();
  callibrate();
  
  //  reset_(1);
}
void (*resetFunc)(void) = 0;
void loop() {
  
//  check_time_reached();
  if(!callibrate_called){  
    if (!reset_called) {      
      if (!autoMode) {
        if (stay_called) {
          uint32_t duration = 0;
        
          if (left_right_dir != 2) {
            duration = end_pan_time - start_pan_time;
            if (buffer_left_right_dir == 0) {
              ptmp += duration;
              if (ptmp / time_for_each_pan_degree >= max_pan_degree)
                ptmp = max_pan_degree * time_for_each_pan_degree;
            }
            else if (buffer_left_right_dir == 1) {
              ptmp -= duration;
              if (ptmp < 0)
                ptmp = 0;
            }
            pan_position = ptmp / time_for_each_pan_degree;
            left_right_dir = 2;
          }
          if (up_down_dir != 2) {
            duration = end_tilt_time - start_tilt_time;
            if (buffer_up_down_dir == 0) {
              ttmp += duration;
              if (ttmp / time_for_each_tilt_degree >= max_tilt_degree)
                ttmp = max_tilt_degree * time_for_each_tilt_degree;
            }
            else if (buffer_up_down_dir == 1) {
              ttmp -= duration;
              if (ttmp < 0)
                ttmp = 0;
            }
            tilt_position = ttmp / time_for_each_tilt_degree;
            up_down_dir = 2;
          }
          stay_called = false;
          sendCurrentPosition(0);
        }
        check_();        
      }
      else {
        if (go_next_preset == true) {
          go_position(array_[counter].pan, array_[counter].tilt);
          update_tilt_pan_value_timer.set_timer(100000);
          counter++;
          go_next_preset = false;
        }
        if (go_next_preset_() && counter == presetCount) {
          counter = 0;
          loadPresets();
          ptmp = 0;
          ttmp = 0;
          myMicros = micros();
          counter_for_callibrate_interval ++;
  
          if (counter_for_callibrate_interval == callibrate_interval) {
            callibrate();
            counter_for_callibrate_interval = 0;
          }
          else
            reset_(1);
        }
        if (update_tilt_pan_value_timer.is_time_reached()) {
          uint32_t tmp = 0;
          tmp = myMicros - start_pan_time;
          if (left_right_dir == 0)
            ptmp += tmp;
          else if (left_right_dir == 1)
            ptmp -= tmp;
          pan_position = ptmp / time_for_each_pan_degree;
  
          tmp = micros() - start_tilt_time;
          tmp /= time_for_each_tilt_degree;
          if (up_down_dir == 0)
            ttmp += tmp;
          else if (up_down_dir == 1)
            ttmp -= tmp;
  
          tilt_position = ttmp;
          //        sendCurrentPosition(1);
          update_tilt_pan_value_timer.set_timer(100000);
        }
      }
    }
    else {
//      if (tilt_timer.is_time_reached() && pan_timer.is_time_reached()) 
      if (digitalRead(left_limit) == LOW && digitalRead(down_limit) == LOW ) {
        go_stay(1);
        pan_position = 0;
        tilt_position = 0;
        reset_called = false;
        autoMode = 1;
        sendCurrentPosition(0);
      }
      go_left();
      go_down();
      check_();
    }
  }
  else{
    if (tilt_timer.is_time_reached() || digitalRead(up_limit) == LOW) {
      if(up_down_callibrate == 0){
        digitalWrite(up_relay_pin, HIGH);
        up_down_callibrate = 1;
        start_up_down_callibrate = micros();
        callibrate();
        tilt_timer.stop_timer();        
        return;
      }
    }
    if (tilt_timer.is_time_reached() || digitalRead(down_limit) == LOW) {
      if(up_down_callibrate == 1){
        digitalWrite(down_relay_pin, HIGH);
        digitalWrite(up_relay_pin, HIGH);
        up_down_callibrate = 2;
        end_up_down_callibrate = micros();
        callibrate();
        tilt_timer.stop_timer();
        return;
      }
    }

    if (pan_timer.is_time_reached() || digitalRead(right_limit) == LOW) {
      if(right_left_callibrate == 0){
        digitalWrite(right_relay_pin, HIGH);
        right_left_callibrate = 1;
        start_right_left_callibrate = micros();
        callibrate();
        pan_timer.stop_timer();
        return;
      }
    }
    if (pan_timer.is_time_reached() || digitalRead(left_limit) == LOW) {
      if(right_left_callibrate == 1){
        digitalWrite(left_relay_pin, HIGH);
        digitalWrite(right_relay_pin, HIGH);
        right_left_callibrate = 2;
        end_right_left_callibrate = micros();
        callibrate();
        pan_timer.stop_timer();
        return;
      }
    }
  }
}


void check_(){
  if (left_right_dir == 1){
    l_r_limit_statue = -1;
    if( digitalRead(left_limit) == LOW){
      digitalWrite(left_relay_pin, HIGH);
      l_r_limit_statue = 1;
    }
  }
  if(left_right_dir == 0){
    l_r_limit_statue = -1;
    if( digitalRead(right_limit) == LOW){
      digitalWrite(right_relay_pin, HIGH);
      l_r_limit_statue = 0;
    }
  }

  if (up_down_dir == 0){
    u_d_limit_statue = -1;
    if( digitalRead(up_limit) == LOW){
      digitalWrite(up_relay_pin, HIGH);
      u_d_limit_statue = 0;
    }
  }
  if(up_down_dir == 1){
    u_d_limit_statue = -1;  
    if( digitalRead(down_limit) == LOW){
      digitalWrite(down_relay_pin, HIGH);
      u_d_limit_statue = 1;
    }
  }
}
void check_time_reached() {
  if (go_pan_timer.is_time_reached()) {
    if (pan_moving) {
      go_stay(0);
      pan_moving = false;
      left_right_dir = 2;

      if (tilt_moving) {
        if (up_down_dir == 1)
          go_up();
        else
          go_down();
      }
    }
  }
  if (go_tilt_timer.is_time_reached()) {
    if (tilt_moving) {
      go_stay(0);
      tilt_moving = false;
      up_down_dir = 2;

      if (pan_moving) {
        if (left_right_dir == 1)
          go_left();
        else
          go_right();
      }
    }
  }
}
boolean go_next_preset_() {
  if ((go_tilt_timer.is_time_reached() && go_pan_timer.is_time_reached())) {
    go_next_preset = true;
    return true;
  }
  else {
    return false;
    go_next_preset = true;
  }
}
void go_position(int pan, int tilt) {
  if (pan < 0) {
    if (digitalRead(left_limit))
      go_left();
    else
      digitalWrite(left_relay_pin, HIGH);

    pan = -pan;
    left_right_dir = 1;
  }
  else if (pan > 0) {
    if (digitalRead(right_limit))
      go_right();
    else
      digitalWrite(right_relay_pin, HIGH);
    left_right_dir = 0;
  }
  pan_moving = true;

  if (tilt < 0) {
    if (digitalRead(down_limit))
      go_down();
    else
      digitalWrite(down_relay_pin, HIGH);
    tilt = -tilt;
    up_down_dir = 0;
  }
  else if (tilt > 0) {
    if (digitalRead(up_limit))
      go_up();
    else
      digitalWrite(up_relay_pin, HIGH);
    up_down_dir = 1;
  }
  tilt_moving = true;

  go_pan_timer.set_timer(time_for_each_pan_degree * pan);
  go_tilt_timer.set_timer(time_for_each_pan_degree * tilt);
}
void reset_(int auto_mode_state) {
  tilt_timer.set_timer(max_tilt_time + 5000000);
  pan_timer .set_timer(max_pan_time + 5000000);
  reset_called = true;
  autoMode = auto_mode_state;
  end_pan_time = 0;
  start_pan_time = 0;
  end_tilt_time = 0;
  start_tilt_time = 0;
  pan_position = 0;
  tilt_position = 0;
  ttmp = 0;
  ptmp = 0;
  tilt_moving = false;
  pan_moving = false;
  buffer_up_down_dir = 0;
  buffer_left_right_dir = 0;
  up_down_dir = 0;
  left_right_dir = 0;

  sendCurrentPosition(0);
}
void go_right() {
  if(l_r_limit_statue == 0){
    digitalWrite(right_relay_pin, HIGH);
    return;
  }
  else
    digitalWrite(right_relay_pin, LOW);
    left_right_dir = 0;
  buffer_left_right_dir = 0;
  start_pan_time = micros(); 
}
void go_left () {
  if(l_r_limit_statue == 1){
    digitalWrite(left_relay_pin, HIGH);
    return;
  }
  else
    digitalWrite(left_relay_pin, LOW);
  left_right_dir = 1;
  buffer_left_right_dir = 1;
  start_pan_time = micros();
  
}
void go_up   () {
  if(u_d_limit_statue == 0){
    digitalWrite(up_relay_pin, HIGH);
    return;
  }
  else
    digitalWrite(up_relay_pin, LOW);

  up_down_dir = 0;
  buffer_up_down_dir = 0;
  start_tilt_time = micros();

//  if(u_d_limit_statue == 1)
//    u_d_limit_statue = -1;
  
}
void go_down () {
  if(u_d_limit_statue == 1){
    digitalWrite(down_relay_pin, HIGH);
    return;
  }
  else
    digitalWrite(down_relay_pin, LOW);
  up_down_dir = 1;
  buffer_up_down_dir = 1;
  start_tilt_time = micros();
   
  
}

void callibrate() {
  callibrate_called = true;
  if (up_down_callibrate == 0){
    digitalWrite(up_relay_pin, LOW);
    tilt_timer.set_timer(max_tilt_time + 50000000);
    return;
  }
  if (up_down_callibrate == 1){
    digitalWrite(down_relay_pin, LOW);
    tilt_timer.set_timer(max_tilt_time + 50000000);
    return;
  }    
  if (up_down_callibrate == 2) {
    Serial.print("Start: ");
    Serial.println(start_up_down_callibrate);
    Serial.print("End: ");
    Serial.println(end_up_down_callibrate);

    Serial.print("Duration: ");
    max_tilt_time = end_up_down_callibrate - start_up_down_callibrate;
    Serial.println(max_tilt_time + "\n");
    up_down_callibrate = 3;
  }
  

  if (right_left_callibrate == 0 && up_down_callibrate == 3){
    digitalWrite(right_relay_pin, LOW);
    pan_timer.set_timer(max_pan_time + 50000000);
    return;
  }
  if (right_left_callibrate == 1) {
    digitalWrite(left_relay_pin, LOW);
    pan_timer.set_timer(max_pan_time + 50000000);
    return;
  }  
  if (right_left_callibrate == 2) {
    Serial.print("Callibrate: ");
    Serial.println(ttmp);
    Serial.print("Start: ");
    Serial.println(start_right_left_callibrate);
    Serial.print("End: ");
    Serial.println(end_right_left_callibrate);

    Serial.print("Duration: ");
    max_pan_time = end_right_left_callibrate - start_right_left_callibrate;
    Serial.println(max_pan_time);

    time_for_each_pan_degree  = round(max_pan_time   / max_pan_degree);
    time_for_each_tilt_degree = round(max_tilt_time  / max_tilt_degree);
    right_left_callibrate = 0;
    up_down_callibrate = 0;
//    autoMode = 1;
//    cali_tmp ++;
//    if(cali_tmp <= 2)
      callibrate();
//    else
//      callibrate_called = false;
  }

  
}
void go_stay (int state) {
  if (left_right_dir != 2)
    end_pan_time  = micros() - start_pan_time;
  if (up_down_dir != 2)
    end_tilt_time = micros() - start_tilt_time;
    
  digitalWrite(up_relay_pin, HIGH);
  digitalWrite(down_relay_pin, HIGH);
  digitalWrite(right_relay_pin, HIGH);
  digitalWrite(left_relay_pin, HIGH);
  if (state == 1) {
    stay_called = true;
    tilt_moving = false;
    pan_moving = false;
    autoMode = 0;
  }
  start_pan_time = 0;
  start_tilt_time = 0;
  sendCurrentPosition(0);
}

void sendCurrentPosition(byte sendIfChanged) {
  byte data[14];
  data[0] = 0xFF;
  data[1] = 0x16;
  data[2] = highByte(pan_position);
  data[3] = lowByte(pan_position);
  data[4] = tilt_position;
  if (laserState == LOW)
    data[5] = 1;
  else
    data[5] = 0;
  data[6] = autoMode;
  data[7] = counter;
  data[8] = presetCount;
  if (callibrate_called)
    data[9] = 1;     //reset to zero point flage
  else
    data[9] = 0;
  data[10] = 0;
  data[11] = 0;
  data[12] = 0;
  for (byte j = 1; j < 12; j++) 
    data[12] ^= data[j];
  
  data[13] = 0xFF;
  Serial.write(data, sizeof(data));
  //  wdt_reset();
  delay(20);
}
void setPreset(byte bytePreset[]) {
  EEpromPreset myPreset;
  myPreset.enable = 1;
  myPreset.panStart = (bytePreset[3] | bytePreset[2] << 8);
  myPreset.panEnd = (bytePreset[5] | bytePreset[4] << 8);
  myPreset.tiltStart = bytePreset[6];
  myPreset.tiltEnd = bytePreset[7];
  myPreset.laserOn = bytePreset[8];
  myPreset.waitTime = bytePreset[9];
  myPreset.panTiltRandomState = bytePreset[10];
  EEPROM.put(bytePreset[11] * 10, myPreset);
  //  wdt_reset();
  for (int i = bytePreset[11] + 1; i < 100; i++)
    clearPreset(i);
}
void clearPreset(byte presetId) {
  EEpromPreset myPreset;
  EEPROM.get(presetId * 10, myPreset);
  if (presetId == 0xFF) {
    for (int i = 0; i < 100; i++) {
      EEPROM.get(i * 10, myPreset);
      if (myPreset.enable == 1) {
        myPreset.enable = 0;
        EEPROM.put(i * 10, myPreset);
      }
    }
  }

  if (myPreset.enable == 1) {
    myPreset.enable = 0;
    EEPROM.put(presetId * 10, myPreset);
  }
}
void setAutoMod(byte onOff) {
  if (onOff == 1) {
    autoMode = true;
    loadPresets();
  }
  else {
    autoMode = false;
    go_stay(1);
  }
}
void setLaserOn(byte onOff) {
  if (onOff == 0)
    laserState = HIGH;
  else
    laserState = LOW;
  digitalWrite(laserPin, laserState);
}
void sendPresets() {
  EEpromPreset myPreset;
  byte data[14];
  data[0] = 0xFF;
  data[1] = 0x18;
  data[13] = 0xFF;
  delay(100);
  for ( int i = 0; i < 100; i++) {
    EEPROM.get(i * 10, myPreset);
    if (myPreset.enable == 1) {
      data[2] = highByte(myPreset.panStart);
      data[3] = lowByte(myPreset.panStart);
      data[4] = highByte(myPreset.panEnd);
      data[5] = lowByte(myPreset.panEnd);

      data[6] = myPreset.tiltStart;
      data[7] = myPreset.tiltEnd;

      data[8] = myPreset.laserOn ;
      data[9] = myPreset.waitTime;
      data[10] = myPreset.panTiltRandomState;
      data[11] = i;
      data[12] = 0x00;
      for (byte j = 1; j < 12; j++)
        data[12] ^= data[j];

      Serial.write(data, 14);
      //      wdt_reset();
      delay(50);
    }
  }
}
void parsCmd(byte cmd[14]) {
  int panByte;
  switch (cmd[1]) {
    case 0x00:
      go_left();
      break;
    case 0x01:
      go_right();
      break;
    case 0x02:
      go_up();
      break;
    case 0x03:
      go_down();
      
      break;
    case 0x04:
      go_stay(1);
      break;
    case 0x05:
      panByte = (cmd[3] | cmd[2] << 8);
      //      panTilt.GotoPosition(panByte, cmd[4], cmd[5], cmd[6]);
      break;
    case 0x06:
      sendCurrentPosition(cmd[2]);
      break;
    case 0x07:
      setPreset(cmd);
      break;
    case 0x08:
      sendPresets();
      break;
    case 0x09:
      clearPreset(cmd[2]);
      break;
    case 0x0A:
      setAutoMod(cmd[2]);
      break;
    case 0x0B:
      setLaserOn(cmd[2]);
      break;
    case 0x0C:
      go_stay(1);
      break;
    default:
      Serial.println("No True Message To Laser Device");
  }
}
void serialEvent() {
//  serial_event_flag = true;
  if(!callibrate_called){
    if (reset_called) {
      pan_position = 0;
      tilt_position = 0;
      left_right_dir = 2;
      up_down_dir = 2;
      sendCurrentPosition(0);
    }
    else {
      int byteCount = -1;
      byte cmd[14];
      byte chkSum = 0;
      byteCount = Serial.readBytes(cmd, 14);
      for (int i = 1; i < 12 ; i++)
        chkSum ^= cmd[i];
      if (cmd[0] == 0xFF && cmd[13] == 0xFF && chkSum == cmd[12]) {
        parsCmd(cmd);
        delay(20);
      } else {
        Serial.println("Error: Noise may be");
        Serial.flush();
      }
    }
  }
  else{
//    go_stay(1);
//    setup(1);
    reset_(0);
    callibrate_called = false;
  }
}
void loadPresets() {
  EEpromPreset myPreset;
  presetCount = 0;
  for (int i = 0; i < 100; i++) {
    EEPROM.get(i * 10, myPreset);

    if (myPreset.enable == 1) {
      if ( myPreset.panTiltRandomState == 0) {
        autoPresets[presetCount].panStart = myPreset.panStart;
        autoPresets[presetCount].tiltStart = myPreset.tiltStart;
      } else if ( myPreset.panTiltRandomState == 1)  {
        autoPresets[presetCount].panStart = random(myPreset.panStart, myPreset.panEnd);
      } else if ( myPreset.panTiltRandomState == 2) {
        autoPresets[presetCount].tiltStart = random(myPreset.tiltStart, myPreset.tiltEnd);
      } else if ( myPreset.panTiltRandomState == 3) {
        autoPresets[presetCount].panStart = random(myPreset.panStart, myPreset.panEnd);
        autoPresets[presetCount].tiltStart = random(myPreset.tiltStart, myPreset.tiltEnd);
      }
      autoPresets[presetCount].laserOn = myPreset.laserOn;
      autoPresets[presetCount].waitTime = myPreset.waitTime;
      presetCount++;
    }
  }
  array_[0].pan = autoPresets[0].panStart;
  array_[0].tilt = autoPresets[0].tiltStart;
  for (int i = 1; i < presetCount; i++) {
    array_[i].pan = autoPresets[i].panStart - autoPresets[i - 1].panStart;
    array_[i].tilt = autoPresets[i].tiltStart - autoPresets[i - 1].tiltStart;
  }
  //    int j = presetCount-1;
  //    for(int i=presetCount; i<presetCount*2; i++){
  //      array_[i].pan = -array_[j].pan;
  //      array_[i].tilt = array_[j--].tilt;
  //    }
  //
  //    presetCount *= 2;
  for (int i = 0; i < presetCount; i++) {
    Serial.print(array_[i].pan);
    Serial.print("    ");
    Serial.println(array_[i].tilt);
  }
  Serial.println();
}
