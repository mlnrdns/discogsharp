﻿using System.Runtime.Serialization;

namespace discogsharp.Domain
{
    public enum Condition
    {
        [EnumMember(Value = "Mint (M)")]
        Mint,

        [EnumMember(Value = "Near Mint (NM or M-)")]
        NearMint,

        [EnumMember(Value = "Very Good Plus (VG+)")]
        VeryGoodPlus,

        [EnumMember(Value = "Very Good (VG)")]
        VeryGood,

        [EnumMember(Value = "Good Plus (G+)")]
        GoodPlus,

        [EnumMember(Value = "Good (G)")]
        Good,

        [EnumMember(Value = "Fair (F)")]
        Fair,

        [EnumMember(Value = "Poor (P)")]
        Poor
    }
}
