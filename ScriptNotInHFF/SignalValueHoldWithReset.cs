using System;

namespace HumanAPI
{
	public class SignalValueHoldWithReset : Node
	{
		public override void Process()
		{
			if (this.onlyTriggerOnce && this.hasTriggered)
			{
				return;
			}
			if (this.input.value > 0f)
			{
				this.bSentOutput = true;
				this.output.SetValue(1f);
			}
			if (this.release.value > 0f)
			{
				this.Reset();
			}
		}

		public void Reset()
		{
			this.hasTriggered = false;
			this.bSentOutput = false;
			this.output.SetValue(0f);
		}

		public NodeInput input;

		public NodeInput release;

		public bool onlyTriggerOnce;

		public NodeOutput output;

		private bool hasTriggered;

		private bool bSentOutput;
	}
}
