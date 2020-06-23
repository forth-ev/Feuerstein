\ VT220 Terminals (und deren Emulatoren wie XTerm) haben zwei
\ Bildschirmspeicher: den primären Bildschirm und den sekundären
\ Bildschirm. Zwischen beiden Bildschirmen kann man mit Terminal Control
\ Sequenzen umschalten. Dabei wird der Inhalt der Bildschirmspeicher nicht
\ verändert.

\ Im Screen muss der "Alternate Screen" angeschaltet werden (CTRL+A
\ :altscreen on), siehe
\ https://stackoverflow.com/questions/17868652/screen-how-to-turn-on-alternate-screen).
\ Wer mit einem "transparenten" Terminalprogramm arbeitet muss nichts ändern.

\ Die Idee ist nun im Forth auf eine bestimmte Tastenkombination zu warten
\ (in meinem Proof-of-Concept CTRL+G) welche in normalem Forth nicht
\ benutzt wird (werden kann, CTRL+G ergibt ASCII 7 "Bell", die Terminal
\ Klingel https://en.wikipedia.org/wiki/Bell_character ).

\ Wir diese Taste gedückt, so wird der Hilfetext relativ zum Cursor
\ angezeigt (es schaut, auf welchem Wort oder hinter welchem Wort der
\ Cursor steht, sucht den Hilfetext und zeigt diesen an). Der PoC macht
\ dies noch *nicht* sondern zeigt erst einmal einen generischen Text an.

\ Hier nun der Forth-Code:

\\ Definition der Terminal Escape Codes

 : esc ( emits escape char ) 1b emit ;
 : termctrl ( emits terminal control string ) ." [?1049" ;
 : altscreen ( switches to alternate screen ) esc termctrl ." h" ;
 : priscreen ( switches to primary screen  )  esc termctrl ." l" ;
 : page ( clear terminal screen ) esc ." [2J" ;

\\ Ausgabe der Hilfe-Texte

 : help altscreen page ." This is the Help-Text" key drop priscreen ;

\\ Neue "key" Routine welche auf CTRL+G ASCII 7 die Hilfe anzeigt

: help-key ( -- c ) serial-key dup 7 = if help then ;

\\ neues Wort "help-key" in den Hook für "key" eintragen

' help-key hook-key !

\ Danach sollte auf CTRL+G der Hilfetest angezeigt werden.
