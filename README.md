# Radioactivity Monitor

This solution contains a small console application that simulates reading
radioactivity levels, along with a separate MSTest project that includes unit
tests for the `Alarm` class.

The `Alarm` class raises an alarm whenever the sensor reading falls outside the
expected range of 17 to 21. To keep the code testable without modifying the main
logic, a simple `ISensor` interface was introduced, and a lightweight
`FakeSensor` is used inside the test project to provide fixed values during
testing.

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

1. Open the solution in **Visual Studio 2022**.  
2. Select **Build > Rebuild Solution**.  
3. Open **Test Explorer** (`Test > Test Explorer`).  
4. Click **Run All** to execute the tests.

All tests should pass.

---

## Unit Testing Approach

- MSTest was used as the testing framework.  
- No mocking framework was used, as required.  
- A simple `FakeSensor` class was created to return controlled values.  
- Constructor injection was added to `Alarm` to allow the sensor to be replaced
  during testing.

The tests cover the following cases:
- Alarm is off by default  
- Values within the range 17–21 do not trigger the alarm  
- Boundary values (17 and 21) are treated as safe  
- Values below 17 trigger the alarm  
- Values above 21 trigger the alarm  

---

## Notes / Possible Improvements

- The condition inside `Alarm.Check()` currently uses bitwise OR (`|`). Using
  logical OR (`||`) would be more idiomatic for boolean expressions.
- `_alarmCount` is incremented but never exposed. It could be returned via a
  property if needed.
- The `Sensor` class creates a new `Random` instance on every reading. Sharing a
  single instance (e.g., using `Random.Shared`) would be more realistic.

