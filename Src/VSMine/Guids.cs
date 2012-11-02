// Guids.cs
// MUST match guids.h
using System;

namespace KoiSoft.VSMine
{
    static class GuidList
    {
        public const string guidVSMinePkgString = "c5aa3c12-65a6-4fb0-982c-59c3e50cccc7";
        public const string guidVSMineCmdSetString = "07fac7fa-269a-42ab-aa7f-3e89ebf47bc2";
        public const string guidToolWindowPersistanceString = "15ce9f51-b9aa-4dfb-845d-8cdb56bb3329";

        public static readonly Guid guidVSMineCmdSet = new Guid(guidVSMineCmdSetString);
    };
}