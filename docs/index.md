# Totally Accurate Fantasy RPG game 

## Development Log
<ul>
  {% for post in site.posts %}
    <li>
      <a href="{{ post.url }}">{{ post.title }}</a>
    </li>
  {% endfor %}
</ul>

## Theme

A top-down 3D soft-body physics RPG dungeon crawler, aimed to be the most immersive (and accurate) fantasy RPG game created.

## Mechanics

Travel from room to room, completing each objective(s) in each room and finding loot along the way.

## Win/Lose

Win:
- Complete all of the objectives in every room.
- Defeat the final boss.

Lose:
- Fail an objective in any room (requires you to restart the room).

## Achievements/Upgrades

### Player Progression

The player will gain experience points, which will allow them to level up and gain skill points. These skill points can be used to increase the player's passive attributes (health, damage, armor, etc).

### Loot
The player will be able to grab weapons that the enemies drop. These weapons will have random attributes assigned to them, which may or may not be better weapon(s) than the player has currently equipped.

## Innovative

The soft-body physics mechanic is heavily-inspired by the game `Totally Accurate Battle Simulator`. We are intrigued by the random chaos and inconsistency that this mechanic adds to the gameplay, and will also require us to use advanced Unity API's to implement.

## Fun

Player progression, random chaos, rooms that follow different themes and emotions, final boss fight, wonky enemies, and much more provide a very unique yet hilarious gameplay.

## Challenging

The soft-body physics adds a bit of chance on whether or not your hits will connect with the enemy. The randomness of the loot drops adds a bit more chance, as you might have a playthrough that doesn't give you any good weapons whereas the next playthrough you could get one of the best weapons early on in the game.

## Prototypes

