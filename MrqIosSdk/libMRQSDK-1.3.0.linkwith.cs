using System;
using ObjCRuntime;

[assembly: LinkWith ("libMRQSDK-1.3.0.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, SmartLink = true, ForceLoad = true)]
