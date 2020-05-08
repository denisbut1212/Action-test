#!/bin/bash

unityPath="D:/Soft/Unity/2019.3.7f1/Editor/Unity.exe"
lastVersion=$(git tag | tail -1)

$unityPath -batchmode -quit -projectPath "../" -executeMethod BuildScript.PerformBuild

{ 
	echo \#define MyAppVersion \"$lastVersion\"
	cat installer.iss;
} > installer.iss.new
mv installer.iss.new installer.iss
