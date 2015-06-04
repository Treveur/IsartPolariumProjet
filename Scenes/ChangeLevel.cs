using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace IsartPolarium
{
	public class ChangeLevel : AScene
	{
		
		Button Lvl1;
		Button Lvl2;
		Button Lvl3;


		public ChangeLevel (SceneManager _SM) : base(_SM)
		{
		}

		/// <summary>
		/// We initialize our scene
		/// </summary>
		public override void Initialize()
		{
			Lvl1 = new Button (this, "1Button");
			Lvl1.Position = new Vector2 (40, sceneManager.graphics.PreferredBackBufferHeight - 50);
			Lvl2 = new Button (this, "2Button");
			Lvl2.Position = new Vector2 (90, sceneManager.graphics.PreferredBackBufferHeight - 50);
			Lvl3 = new Button (this, "3Button");
			Lvl3.Position = new Vector2 (140, sceneManager.graphics.PreferredBackBufferHeight - 50);

			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
			AddEntity (Lvl1);
			AddEntity (Lvl2);
			AddEntity (Lvl3);

			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{
			if (Lvl1.changed) {
				ChangeSceneState (Lvl1._state, Lvl2._state, Lvl3._state, sceneManager.GetScene(0));
				Lvl1.changed = false;
			}

			if (Lvl2.changed) {
				ChangeSceneState (Lvl2._state, Lvl1._state, Lvl3._state, sceneManager.GetScene(1));
				Lvl2.changed = false;
			}

			if (Lvl3.changed) {
				ChangeSceneState (Lvl3._state, Lvl1._state, Lvl2._state, sceneManager.GetScene(3));
				Lvl3.changed = false;
			}

			base.Update (gameTime);
		}
			

		void ChangeSceneState(bool LvlenCoursState, bool autreLvl1, bool autreLvl2, AScene sceneToChange)
		{
			/*if (LvlenCoursState && autreLvl1 == false && autreLvl2 == false)
				sceneToChange.sceneState = SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				sceneToChange.sceneState = SceneState.DRAW;
			else if (upd && dra == false)
				sceneToChange.sceneState = SceneState.UPDATE;
			else if (upd == false && dra == false)
				sceneToChange.sceneState = SceneState.SLEEP;*/
		}

		/// <summary>
		/// We draw all the entity of our scene
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}

