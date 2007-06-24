/* 
 * Copyright 2004-2006 OpenSymphony 
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not 
 * use this file except in compliance with the License. You may obtain a copy 
 * of the License at 
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0 
 *   
 * Unless required by applicable law or agreed to in writing, software 
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT 
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations 
 * under the License.
 */
using System;

using NUnit.Framework;

using Quartz.Impl.Calendar;

namespace Quartz.Tests.Unit
{

	/// <summary>
	/// Unit test for AnnualCalendar serialization backwards compatibility.
	/// </summary>
	public class AnnualCalendarTest : SerializationTestSupport
	{
		private static string[] VERSIONS = new string[] {"1.5.1"};

		//private static final TimeZone EST_TIME_ZONE = TimeZone.getTimeZone("America/New_York"); 

		/// <summary>
		/// Get the object to serialize when generating serialized file for future
		/// tests, and against which to validate deserialized object.
		/// </summary>
		/// <returns></returns>
		protected override object GetTargetObject()
		{
			AnnualCalendar c = new AnnualCalendar();
			c.Description = "description";
			DateTime cal = new DateTime(2005, 1, 20, 10, 5, 15);
			c.SetDayExcluded(cal, true);
			return c;
		}

		/// <summary>
		/// Get the Quartz versions for which we should verify
		/// serialization backwards compatibility.
		/// </summary>
		/// <returns></returns>
		protected override string[] GetVersions()
		{
			return VERSIONS;
		}

		/// <summary>
		/// Verify that the target object and the object we just deserialized 
		/// match.
		/// </summary>
		/// <param name="target"></param>
		/// <param name="deserialized"></param>
		protected override void VerifyMatch(object target, object deserialized)
		{
			AnnualCalendar targetCalendar = (AnnualCalendar) target;
			AnnualCalendar deserializedCalendar = (AnnualCalendar) deserialized;

			Assert.IsNotNull(deserializedCalendar);
			Assert.AreEqual(targetCalendar.Description, deserializedCalendar.Description);
			Assert.AreEqual(targetCalendar.DaysExcluded, deserializedCalendar.DaysExcluded);
			///Assert.IsNull(deserializedCalendar.getTimeZone());
		}
	}
}