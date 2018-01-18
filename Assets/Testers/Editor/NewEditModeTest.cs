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
	    
        Assert.IsInstanceOf<int>(player.getHealth());
		yield return null;
	}

    [UnityTest]
    public IEnumerator CharacterHasMaxHealthAsInt()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<int>(player.getMaxHealth());
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterTakesDamage()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        int startHealth = player.getHealth();
        player.takeDamage(5);
        int endHealth = player.getHealth();

        Assert.True(startHealth == endHealth + 5);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterDoesNotHealWhenFullHealth()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        int startHealth = player.getHealth();
        player.doHeal(10);
        int endHealth = player.getHealth();

        Assert.True(startHealth == endHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterDoesHeal()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.setHealth(5);
        int startHealth = player.getHealth();
        player.doHeal(5);
        int endHealth = player.getHealth();

        Assert.True(startHealth + 5 == endHealth);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterTestGetAbilities()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<List<Ability>>(player.getAbilities());
        Assert.True(player.getAbilities().Count == 4);

        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterrHasFourAbilitiesOfTypeAbility()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        foreach (var ability in player.getAbilities())
        {
            Assert.True(ability is Ability);
        }

        
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterInitializeHealth()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.initializeHealth(20);

        Assert.True(player.getHealth() == 20 && player.getMaxHealth() == 20);

        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerHasAPAsInt()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<int>(player.getCurrentAP());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerHasMaxAPAsInt()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        Assert.IsInstanceOf<int>(player.getMaxAP());
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerSetsAP()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        player.setCurrentAP(5);
        Assert.True(player.getCurrentAP() == 5);
        yield return null;
    }

    [UnityTest]
    public IEnumerator PlayerUseAP()
    {
        Player player = new Player(Player.PlayerType.CompSci);

        int startAP = player.getCurrentAP();
        player.useAP(5);
        int endAP = player.getCurrentAP();

       Assert.True(startAP == endAP + 5);
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterSetTickingDamage()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.setTickingDamage(true);

        Assert.True(player.getTickingDamage());
        yield return null;
    }

    [UnityTest]
    public IEnumerator CharacterTakeTickingDamage()
    {
        Player player = new Player(Player.PlayerType.CompSci);
        player.setTickingDamagePerTurn(10);

        Assert.True(player.getTickingDamagePerTurn() == 10);
        yield return null;
    }

}
