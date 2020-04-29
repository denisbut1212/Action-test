#!/bin/bash

lastVersion=$(git tag | tail -1)
echo $lastVersion
