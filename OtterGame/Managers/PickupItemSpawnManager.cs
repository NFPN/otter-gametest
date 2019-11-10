﻿using Otter;
using OtterGameSetup.Entities;
using OtterGameSetup.Extensions;
using System.Collections.Generic;

namespace OtterGameSetup.Managers
{
    public class PickupItemSpawnManager
    {
        private const int MAXITEMS = 3;
        private Game CurrentGame { get; set; }
        public List<PickupItem> PickupItems { get; private set; }

        public PickupItemSpawnManager(Game game)
        {
            CurrentGame = game;
            Start();
        }

        private void Start()
        {
            PickupItems = new List<PickupItem>();

            for (int i = 0; i < MAXITEMS; i++)
                PickupItems.Add(new PickupItem().ChangePosition(CurrentGame));
        }

        public void CollidedWith(PickupItem item) => item.ChangePosition(CurrentGame);
    }
}