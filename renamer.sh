#!/bin/bash

old="_template_"
new="$1"

if [ -e "../$new.Solution" ]
then
  echo this project already exists
  exit 1
fi

cp -r . "../$new.Solution"
cd "../$new.Solution"
rm renamer.sh

list()
{
  for file in *
  do
    if [ "$file" != "bin" ] && [ "$file" != "obj" ] && [ "$file" != ".git" ]
    then
      if [ -d "$file" ]
      then
        cd $file
        local currentFile=$file
        list
        file=$currentFile
        cd ..
      else
        sed -i -e "s/$old/$new/g" "$file"
      fi

      newname="${file/$old/$new}"
      oldname="$file"
      if [ "$oldname" != "$newname" ]
      then
        mv "$oldname" "$newname" && echo "$oldname > $newname"
      fi
      
    fi
  done
}

list
