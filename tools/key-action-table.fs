\ action words to execute
: action1 ." action 1" cr ;
: action2 ." action 2" cr ;
: action3 ." action 3" cr ;

\ table of execution tokens for actions
create actiontable
  ' action1 , ' action2 , ' action3 ,

\ execute action by index
: decide ( n -- ) cells actiontable + @ execute ;

\ table of keyboard values
create keytable
  char a ,   char x ,   char 6 , 

\ calculate number of keys
here keytable - cell / Constant #keys

\ convert key in action execution token
: keyaction ( key -- addr )
  #keys 0 do
  dup keytable
  i cells +
  @ = if
    drop actiontable i cells + @ unloop exit
  then
  loop drop
  actiontable @ \ default action
  ;

 \ test routine
 : test begin
   key keyaction execute
  again ;
