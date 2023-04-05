#ifndef MYTIMER_H
#define MYTIMER_H
class MyTimer {
  public:
    MyTimer();
    bool is_time_reached();
    void set_timer(unsigned long);
    void stop_timer();
  private:
    unsigned long _start_time = 0;
    unsigned long _period = 0;
    unsigned long _current_time = 0;
    boolean _is_reached = false;
    boolean stop_called = false;
};

#endif
