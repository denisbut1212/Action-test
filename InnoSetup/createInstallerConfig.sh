#!/bin/bash
lastVersion=$(git tag | tail -1)
cd InnoSetup
{ 
	echo \#define MyAppVersion \"$lastVersion\"
	cat installerTemplate.iss
} > installer.iss
