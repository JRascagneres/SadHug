using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class NewEditModeTest {

	[UnityTest]
	public IEnumerator CharacterHasHealthAsInt()
	{
	    Player player = new Player(Player.PlayerType.CompSci);
	    
        Assert.IsInstanceOf<int>(player.GetHealth());
		yield return null;
	}

    [UnityTest]
    public IEnumerator CharacterHasMaxHealthAsInt()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<int>(player.GetMaxHealth());
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterTakesDamage()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        int startHealth = player.GetHealth();
        player.TakeDamage(5);
        int endHealth = player.GetHealth();

        Assert.True(startHealth == endHealth + 5);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterDoesNotHealWhenFullHealth()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        int startHealth = player.GetHealth();
        player.DoHeal(10);
        int endHealth = player.GetHealth();

        Assert.True(startHealth == endHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterDoesHeal()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.SetHealth(5);
        int startHealth = player.GetHealth();
        player.DoHeal(5);
        int endHealth = player.GetHealth();

        Assert.True(startHealth + 5 == endHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterTestGetAbilities()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<List<Ability>>(player.GetAbilities());
        Assert.True(player.GetAbilities().Count == 4);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterrHasFourAbilitiesOfTypeAbility()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        foreach (var ability in player.GetAbilities())
        {
            Assert.True(ability is Ability);
        }

        
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterInitializeHealth()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.InitializeHealth(20);

        Assert.True(player.GetHealth() == 20 && player.GetMaxHealth() == 20);

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerHasApAsInt()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<int>(player.GetCurrentAp());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerHasMaxApAsInt()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<int>(player.GetMaxAp());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerSetsAp()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        player.SetCurrentAp(5);
        Assert.True(player.GetCurrentAp() == 5);
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerUseAp()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        int startAp = player.GetCurrentAp();
        player.UseAp(5);
        int endAp = player.GetCurrentAp();

       Assert.True(startAp == endAp + 5);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterSetTickingDamage()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.SetTickingDamage(true);

        Assert.True(player.GetTickingDamage());
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterTakeTickingDamage()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.SetTickingDamagePerTurn(10);

        Assert.True(player.GetTickingDamagePerTurn() == 10);
        yield return null;
    }

}
