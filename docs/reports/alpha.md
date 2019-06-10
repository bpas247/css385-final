# Totally Accurate Fantasy RPG game 

## [Home](../index.md)

## Alpha Release Playtesting Reports

> Sometimes it was hard to tell what to do to progress.  The objective listed in the UI helps a little bit but sometimes it could be difficult to know if you missed something.

From this feedback, we decided it would be beneficial for the user to be able to know which direction they should go to in order to progress through the objectives. We ended up implementing an objective indicator UI to handle this use case for the beta release.

> Character moves rather quickly, can be hard to control.

> The movement of the characters (both player and enemies) is a little chaotic, and I'm not a huge fan of that, but that's just a personal preference.

This is something we've attempted to do in the final release, but it's difficult to find the right balance. For example, we had some users say the controls
worked just fine as it is, while others found the controls pretty frustrating. The way that we've attempted to incorporate this feedback is mainly in 
the balancing of the physics system, by manipulating the mass of each body part for the human models. 

> I’d like for there to be an indicator that the enemies have died (a different color, X’s for eyes, etc.), because it could be difficult to tell when they’ve been defeated.

We ended up directly implementing this feature, so now the text will turn green to indicate to move on to the next room. 