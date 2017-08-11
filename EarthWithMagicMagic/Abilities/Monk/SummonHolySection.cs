﻿using EarthMagicCreatures.Creatures.Heavenly.Angels;
using EarthWithMagicAPI.API.Creature;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicMagic.Abilities.Monk
{
    /// <summary>
    /// Summons 4 lesser angels.
    /// </summary>
    public class SummonHolySection : IAbility
    {
        public SummonHolySection(int uses) : base("Summon Holy Section", "EarthMagicDocumentation.Abilities.Summon Holy Section.md", false, uses)
        {
        }

        public override void Go(List<ICreature> Party, List<ICreature> Enemies, ICreature Caster)
        {
            Party.Add(new LesserAngel());
            Party.Add(new LesserAngel());
            Party.Add(new LesserAngel());
            Party.Add(new LesserAngel());
        }

        //public void ApplyToCreature(ICreature creature, List<ICreature> Party, List<ICreature> Enemies)
        //{

        //}
    }
}