using System;

namespace xmcustom.view
{
	public class MyModel
	{
		public string lbl1{ get; set;}
		public string lbl2{ get; set;}

		public MyModel (string lbl1, string lbl2)
		{
			this.lbl1 = lbl1;
			this.lbl2 = lbl2;
		}

		public override string ToString ()
		{
			return string.Format ("[MyModel] {0} + {1}", lbl1, lbl2);
		}
	}
}

