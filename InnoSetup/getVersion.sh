#!/bin/bash

lastVersion=$(git tag | tail -1)
{ 
	echo \#define MyAppVersion \"$lastVersion\"
	sed 
	cat installer.iss;
} > installer.iss.new
mv installer.iss.new installer.iss