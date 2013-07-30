file=editor_errors.txt
if [ $# -eq 1 ]; then
  file=$1
fi
filetmp=$file.tmp
grep "\* Details" ~/Library/Logs/Unity/Editor.log | cut -d ':' -f 2- | tee $filetmp
cp $filetmp $file
echo "all errors" | tee -a $file 
wc -l $filetmp | tee -a $file
echo "Unique errors:" | tee -a $file
cat $filetmp | sort -u | wc -l | tee -a $file
rm $filetmp