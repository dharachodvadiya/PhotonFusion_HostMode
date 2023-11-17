using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hostMode
{
    public class Ball : NetworkBehaviour
    {
        [Networked] private TickTimer life { get; set; }

        public void Init()
        {
            life = TickTimer.CreateFromSeconds(Runner, 5.0f);
        }
        public override void FixedUpdateNetwork()
        {
            if (Runner.IsServer)
            {
                if (life.Expired(Runner))
                    Runner.Despawn(Object);
                else
                    transform.position += 5 * transform.forward * Runner.DeltaTime;
            }

        }
    }
}
