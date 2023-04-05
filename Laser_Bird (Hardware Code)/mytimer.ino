#include "mytimer.h"

MyTimer::MyTimer() {
}

void MyTimer::set_timer(unsigned long period) {
  stop_called = false;
  _is_reached = false;
  _period = period;
  _start_time = micros();
}

bool MyTimer::is_time_reached() {
  if(!stop_called){
    if(!_is_reached){
      _current_time = micros();
      if (_period < _current_time - _start_time){
        _is_reached = true;
        return true;    
      }
      else
        return false;
    }
    else
      return true;
  }
  else
    return false;
  
}
void MyTimer::stop_timer(){
  stop_called = true;
}
