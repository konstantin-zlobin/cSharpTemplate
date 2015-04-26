using System;
using System.Collections.Generic;

namespace cSharpTemplate
{
	public class ClubEvent
	{
	    private DateTime _time;
	    private DateTime _date;

	    public String Title { get; set; }

	    public DateTime Date
	    {
	        get { return _date; }
	        set { _date = value.Date; }
	    }

	    public DateTime Time
	    {
            get { return _time; }
	        set { _time = new DateTime(1, 1, 1, value.Hour, value.Minute, value.Second); }
	    }

	    public IEnumerable<string> Performers { get; set; }
	}
}
