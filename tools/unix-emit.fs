\ dem Mecrisp CRLF Zeilenenden beibringen (Carriage-Return +
\ Line-Feed), so das die Ausgabe um Linux/Unix-Terminal funktioniert
\ (z.B. unter "screen"

hex
: unix-emit ( c -- ) dup 0a = if 0d serial-emit then serial-emit ;
' unix-emit hook-emit !

\ Hier "hänge" ich mich in die Zeichenausgabe des Forth ein, mit einem
\ neuen "unix-emit". Dieses Wort prüft ob das auszugebene Zeichen ein $0A
\ (Linefeed) ist, und wenn ja, dann wird noch zusätzlich ein $0D
\ (Carriage-Return) mit ausgegeben (via "serial-emit").

\ Dieses neue "unix-emit" wird dann in den "emit-hook" eingetragen, so das
\ nun "unix-emit" statt "serial-emit" von "emit" aufgerufen wird.

\ Nun kann ich Mecrisp von "screen" im XTerm aus benutzen mit

\ screen /dev/ttyUSB0 115200
