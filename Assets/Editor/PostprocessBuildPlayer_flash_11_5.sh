#!/bin/bash

# FORCE FLASH 11_5, even if not supported by UNITY
#
# this requires to do something like
# cd $UNITY_HOME/Contents/PlaybackEngines/FlashSupport/BuildTools/flex/frameworks/libs/player/
# ln -s 11.4 11.5

install_path=$1
target_platform=$2

filename=$(basename "$install_path")
extension="${filename##*.}"

if [[ $extension != "swf" ]]; then
    exit
fi

# comment out to disable forcing 11_5
#exit

UNITY_HOME=`grep "MONO_PATH" ~/Library/Logs/Unity/Editor.log | head -1 | sed 's/.* \(.*\)\/Contents.*/\1/'`
PWD=`pwd`

if [[ ! -d $UNITY_HOME ]]; then
	echo "Couldn't find UNITY_HOME $UNITY_HOME"
	exit -1	
fi

# the 2 following commands are parametrize version of the commands Unity outputs in the editor.log
# if you change your build options, or your paths, you will need to adjust...
java -Xmx768m -Dsun.io.useCanonCaches=false -Duser.region=US -Duser.language=en -jar "$UNITY_HOME/Contents/PlaybackEngines/FlashSupport/BuildTools/Flex/lib/mxmlc.jar" +flexlib="$UNITY_HOME/Contents/PlaybackEngines/FlashSupport/BuildTools/Flex/frameworks" "$UNITY_HOME/Contents/PlaybackEngines/FlashSupport/BuildTools/UserBuild_AS3/UnityApp.as" -debug=false -optimize=true -include-libraries="$UNITY_HOME/Contents/PlaybackEngines/FlashSupport/UnityNative11dot2.swc"  -source-path='Temp/StagingArea/Data/src' -source-path='Temp/StagingArea/Data/ConvertedDotNetCode' -source-path="$UNITY_HOME/Contents/PlaybackEngines/FlashSupport/BuildTools/UserBuild_AS3" -source-path="$PWD/Assets/ActionScript" -static-link-runtime-shared-libraries=true -swf-version=18 -default-size 960 600 -omit-trace-statements=false -default-script-limits=1000,60 -target-player=11.5.0 -verbose-stacktraces=true -compress=false -define+=UNITY_FLASH::TargetFlashPlayerVersion,"'11.5.0'" -define+=UNITY_FLASH::TargetSwfVersion,"'18'" -define+=UNITY_FLASH::PLAYERFEATURE_LEVEL_11dot2,true -define+=UNITY_FLASH::PLAYERFEATURE_LEVEL_11dot3,true -define+=UNITY_FLASH::PLAYERFEATURE_LEVEL_11dot4,true  -output="$PWD/Temp/StagingArea/Data/temp.swf"

$UNITY_HOME/Contents/Frameworks/MonoBleedingEdge/bin/mono "$UNITY_HOME/Contents/PlaybackEngines/FlashSupport/BuildTools/SwfPostProcessor.exe"  -nativeskip -upp "$PWD/Temp/StagingArea/Data/temp.swf" -o "$PWD/Temp/StagingArea/Data/temp.swf" -clzma  -inject-telemetry 

cp $install_path ${install_path}.old
cp $PWD/Temp/StagingArea/Data/temp.swf $install_path
