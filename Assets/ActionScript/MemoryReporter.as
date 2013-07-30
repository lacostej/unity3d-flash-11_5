package
{
	import flash.system.System;

	public class MemoryReporter
	{
	    public static function ReportMem() : String {
			return "MEM: (P/T/F)" + PrettyMemSize(System.privateMemory) + "/" + PrettyMemSize(System.totalMemory) + "/" + PrettyMemSize(System.freeMemory);
	    }

	    private static function PrettyMemSize(Size: Number): String {
	    	var unit = "";
	    	if (Size > 1000) {
	    		unit = "k";
	    		Size = Size / 1000;
	    	}
	    	if (Size > 1000) {
	    		unit = "M";
	    		Size = Size / 1000;
	    	}
	    	return "" + Math.floor(Size) + " " + unit;
	    }

	}
}