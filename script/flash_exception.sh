#!/bin/bash
# opens sublime directly on the failed line of the first exception
# see http://www.sublimetext.com/docs/2/osx_command_line.html
fileline=`grep "at global" ~/Library/Preferences/Macromedia/Flash\ Player/Logs/flashlog.txt | head -1 | sed 's/.*\[\(.*\)\].*/\1/'`
subl $fileline

# trunc at first exception
sed '/Filename/,$ d' ~/Library/Preferences/Macromedia/Flash\ Player/Logs/flashlog.txt  | less


