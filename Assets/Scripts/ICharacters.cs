using System.Collections;
using System.Collections.Generic;

/*
 * Author: Alam Rodriguez.
 * This is an interface which contains functions for the characters in the game (player, enemies, robots)
 */
public interface ICharacters
{
    public int Health { get; set; }
    public int MaxHealth { get; }

    public void TakeDamage(int _damage = 1);

    public void Attack();

    public void Die();

}
