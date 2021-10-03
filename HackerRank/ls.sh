#!/bin/sh 
#ls -lrcFRh > readme.md

git ls-tree -r master --name-only  > readme.md

