using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BRSTMConverter {
	class SubRangeProgressTracker : IProgressTracker {
		private IProgressTracker output;

		private float outputStart;
		private float outputEnd;

		private float getRealValue(float inputValue) {
			float working = inputValue;
			working -= MinValue;
			working /= (MaxValue - MinValue) / (outputEnd - outputStart);
			working += outputStart;
			return working;
		}

		private float getInputValue(float realValue) {
			float working = realValue;
			working -= outputStart;
			working *= (MaxValue - MinValue) / (outputEnd - outputStart);
			working += MinValue;
			return working;
		}

		public SubRangeProgressTracker(float outputStart, float outputEnd, IProgressTracker output) {
			this.outputStart = outputStart;
			this.outputEnd = outputEnd;
			this.output = output;
		}

		public void Update(float value) {
			output.Update(getRealValue(value));
		}

		public void Begin(float min, float max, float current) {
			MinValue = min;
			MaxValue = max;
			Update(current);
		}

		public void Finish() {
			Update(MaxValue);
		}

		public void Cancel() {
			output.Cancel();
		}

		public float MinValue { get; set; }

		public float MaxValue { get; set; }

		public float CurrentValue {
			get {
				return getInputValue(output.CurrentValue);
			}
			set {
				output.CurrentValue = getRealValue(value);
			}
		}

		public bool Cancelled {
			get {
				return output.Cancelled;
			}
			set {
				output.Cancelled = value;
			}
		}
	}
}
