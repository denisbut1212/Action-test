#!/bin/bash

lastVersion=$(git tag | tail -1)
cd InnoSetup
{ 
	echo \#define MyAppVersion \"$lastVersion\"
	cat installer.iss; 
} > installer.iss.new
mv installer.iss.new installer.iss
