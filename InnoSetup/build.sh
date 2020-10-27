#!/bin/bash
lastVersion=$(git tag | tail -1)
{ 
	echo \#define MyAppVersion \"$lastVersion\"
	cat InnoSetup/installer.iss;
} > installer.iss.new

mv installer.iss.new InnoSetup/installer.iss

InnoSetup/ISCC.exe "/DMyAppName=Познавательная Реальность" installer.iss
