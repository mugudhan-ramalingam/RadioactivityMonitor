# Radioactivity Monitor

This repository contains a small console application and a set of unit tests for the 'Alarm' class.  
The 'Alarm' is responsible for checking radioactivity values coming from a sensor and triggering the alarm when the reading goes outside the allowed range.

---

## Project Structure

RadioactivityMonitor/
├─ RadioactivityMonitor
│  ├─ Core/
│  │  ├─ Alarm.cs
│  │  ├─ Sensor.cs
│  │  └─ ISensor.cs
│  └─ Program.cs
│
└─ RadioactivityMonitor.Tests
   ├─ AlarmTests.cs
   └─ MSTestSettings.cs

---

## How to Build and Run

1. Open the solution file below using Visual Studio 2022:  
		RadioactivityMonitor/RadioactivityMonitor/RadioactivityMonitor.sln 
2. Select 'Build' --> Build Solution.  
3. Open 'Test Explorer'
4. Click 'Run All' to execute the tests.

All tests should pass.

---

## Unit Testing Approach

- The tests follow the standard Arrange → Act → Assert format.
- Since mocking frameworks were not allowed, a simple FakeSensor was introduced to provide fixed readings during tests.

The tests cover the following cases:
- Alarm is off by default  
- Values within the range 17–21 do not trigger the alarm  
- Boundary values (17 and 21) are treated as safe  
- Values below 17 trigger the alarm  
- Values above 21 trigger the alarm  

---

