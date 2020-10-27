#!/bin/bash

unityPath="D:/Soft/Unity/2019.4.11f1/Editor/Unity.exe"
lastVersion=$(git tag | tail -1)

$unityPath -batchmode -quit -executeMethod Build.Perform

{ 
	echo \#define MyAppVersion \"$lastVersion\"
	cat InnoSetup/installer.iss;
} > installer.iss.new

mv installer.iss.new installer.iss
