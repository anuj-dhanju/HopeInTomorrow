
	    var x = decodeURIComponent(window.location.toString());

	    if (x.indexOf('.com') > -1)
	    {
	        y = x.replace('.com', '.org');
	        window.location = y;
	    }
