#!/bin/bash

UNITY_PATH="D:/Soft/Unity/2019.3.7f1/Editor/Unity.exe" 
rm -rf ../build
rm build.log
$UNITY_PATH –quit -batchmode -ProjectPath "../" -executeMethod BuildScript.PerformBuild -logFile build.log
echo finish build
