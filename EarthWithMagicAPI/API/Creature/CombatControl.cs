﻿using System.Linq;
using EarthWithMagicAPI.API.Interfaces.Items;
using EarthWithMagicAPI.API.Util;
using EarthWithMagicAPI.API.Interfaces.Spells;
using EarthWithMagicAPI.API.Stuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace EarthWithMagicAPI.API.Creature
{
    /// <summary>
    /// Gives the player options for each creature in their party in combat.
    /// </summary>
    public static class CombatControl
    {
        public static void YourTurn(ICreature creature, Encounter encounter)
        {
            string Input = "";
            string[] Command = Input.Split(' ');
            while (Input != "end turn")
            {
                Input = Console.ReadLine().ToLower();

                switch (Input)
                {
                    case "help":
                        Help(creature, encounter, Command);
                        break;
                    case "view inventory":
                        ViewInventory(creature, encounter, Command);
                        break;
                    case "equip":
                        Equip(creature, encounter, Command);
                        break;
                    case "swing":
                        Swing(creature, encounter, Command);
                        break;
                    case "use ability":
                        UseAbility(creature, encounter, Command);
                        break;
                    case "list abilities":
                        ListAbilities(creature, encounter, Command);
                        break;
                    case "cast":
                        Cast(creature, encounter, Command);
                        break;
                    case "list spells":
                        ListSpells(creature, encounter, Command);
                        break;
                    case "use":
                        Use(creature, encounter, Command);
                        break;
                    case "list enemies":
                        ListEnemies(creature, encounter, Command);
                        break;
                    case "list party":
                        ListParty(creature, encounter, Command);
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ListAbilities(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (IAbility item in creature.ClassAbilities)
            {
                Util.Util.WriteLine(item.Name + " [" + item.AvailibleUses.ToString() + "]");
            }
        }

        private static void UseAbility(ICreature creature, Encounter encounter, string[] Command)
        {
            if (Command.Length < 2)
            {
                Util.Util.WriteLine("Missing argument!");
            }
            else
            {
                foreach (IAbility item in creature.ClassAbilities)
                {
                    if (item.Name == Command[1])
                    {
                        if (item.AvailibleUses > 0)
                        {
                            item.Go(encounter.Party, encounter.Enemies, creature);
                        }
                        else
                        {
                            Util.Util.WriteLine("Ability has been used up!");
                        }

                        return;
                    }
                }

                Util.Util.WriteLine("Ability not found!");
            }
        }

        private static void ListSpells(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ISpell item in creature.UsableSpells)
            {
                Util.Util.WriteLine(item.Name + ", " + item.PowerRequired.ToString());
            }
        }

        private static void ListParty(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ICreature item in encounter.Party)
            {
                Util.Util.WriteLine(item.Name + " HP: [" + item.GetAttributes().Health.ToString() + "]");
            }
        }

        private static void ListEnemies(ICreature creature, Encounter encounter, string[] Command)
        {
            foreach (ICreature item in encounter.Enemies)
            {
                Util.Util.WriteLine(item.Name + " HP: [" + item.GetAttributes().Health.ToString() + "]");
            }
        }

        private static void Use(ICreature creature, Encounter encounter, string[] Command)
        {
            if (Command.Length < 2)
            {
                Util.Util.WriteLine("Missing argument!");
            }
            else
            {
                List<IItem> Items = new List<IItem>();
                Items.AddRange(creature.Amulets);
                Items.AddRange(creature.Armoring);
                Items.AddRange(creature.Inventory);
                Items.AddRange(creature.Rings);
                Items.AddRange(creature.Weapons);

                foreach (IItem item in Items)
                {
                    if (item.Name == Command[1])
                    {
                        item.Use();
                        return;
                    }
                }

                Util.Util.WriteLine("Item not found!");
            }
        }

        private static void Cast(ICreature creature, Encounter encounter, string[] Command)
        {
            if (Command.Length > 1)
            {
                foreach (ISpell item in creature.SpellsKnown)
                {
                    if (item.Name == Command[1])
                    {
                        if (item.PowerRequired > creature.CastingPower)
                        {
                            Util.Util.WriteLine("Not enough casting power!");
                        }
                        else
                        {
                            creature.CastingPower -= item.PowerRequired;
                            item.Go(encounter.Party, encounter.Enemies, creature);
                        }
                    }
                }

                Util.Util.WriteLine("Spell not found!");
            }
            else
            {
                Util.Util.WriteLine("Missing argument!");
            }
        }

        private static void Swing(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void Equip(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }

        private static void ViewInventory(ICreature creature, Encounter encounter, string[] Command)
        {
            string Items = "";
            foreach (IItem item in creature.Amulets)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Armoring)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Inventory)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Rings)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
            Items = "";
            foreach (IItem item in creature.Weapons)
            {
                Items += item.Name;
                Items += ", ";
            }
            Util.Util.WriteLine(Items);
        }

        /// <summary>
        /// Displays some help information.
        /// </summary>
        private static void Help(ICreature creature, Encounter encounter, string[] Command)
        {
            throw new NotImplementedException();
        }
    }
}