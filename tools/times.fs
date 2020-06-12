\ # the utility word "times" executes the words in the input like
\ # multiple times
\ # 
\ # "times" is useful for debugging words that take an address, display
\ # a data structure and return the address of the next data structure
\ # in memory

\ variable to hold the numer of loops through the 
\ input line

0 Variable #times 

\ writes the value '0' into an address
\ often used to switch off a function
\ example use "warning off"

: off ( a-addr -- ) 
  0 swap ! ;

\ executes the input line from the beginning "n" times
\ "n" = 0 creates an endless loop
\ this word resets the pointer to the current 
\ interpreter location to create loops
\ through the input line
\ this only works in interpretation mode, not in 
\ compiled words

: times ( n -- )
    ?dup if #times @ 2+ u<
        if #times off exit then
        1 #times +!
        then >IN off ;

