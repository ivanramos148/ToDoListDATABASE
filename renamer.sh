#!/bin/bash

old="_template_"
new="$1"

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
      if [ "$oldname" != "$newname" ] && [ -e $file ]
      then
        mv "$oldname" "$newname" && echo "$oldname > $newname"
      fi
      
    fi
  done
}

list
