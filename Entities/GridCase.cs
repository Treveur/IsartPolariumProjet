using System;
using Microsoft.Xna.Framework;

namespace IsartPolarium
{
	public class GridCase : AEntity
	{
		public GameCase[] caseTab;
		protected int width;
		protected int heigth;

		//Protected
		protected int[,] levelStructure;

		//enum e_state pour verification de la victoire
		public enum e_state
		{
			ON_DRAG,
			PILE,
			FACE,
			SPECIAL_PILE,
			SPECIAL_FACE,
			GRAY
		}


		public override Vector2 Position {
			set {
				this._position = value;
				int count = 0;
				for (int i = 0; i < width; i++)
				{
					for (int j = 0; j < heigth; j++)
					{
						caseTab[count].Position = new Vector2(_position.X + caseTab[count].Size.X + caseTab[count].Size.X * i,
							_position.Y + caseTab[count].Size.Y + caseTab[count].Size.Y * j);
						count++;
					}
				}
			}
			get {
				return _position;
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IsartPolarium.GridCase"/> class with size of the grid on width and heigth.
		/// </summary>
		/// <param name="scene">Scene.</param>
		/// <param name="newWidth">New width.</param>
		/// <param name="newHeigth">New heigth.</param>
		public GridCase (AScene scene, int newWidth, int newHeigth) : base (scene)
		{
			width = newWidth;
			heigth = newHeigth;
			caseTab = new GameCase[width * heigth];
			int count = 0;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < heigth; j++)
				{
					caseTab[count] = new GameCase(scene);
					scene.AddEntity(caseTab[count]);
					caseTab[count].Position = new Vector2(_position.X + caseTab[count].Size.X + caseTab[count].Size.X * i,
						_position.Y + caseTab[count].Size.Y + caseTab[count].Size.Y * j);
					count++;
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IsartPolarium.GridCase"/> class with size of the grid on width and heigth.
		/// </summary>
		/// <param name="scene">Scene.</param>
		/// <param name="newWidth">New width.</param>
		/// <param name="newHeigth">New heigth.</param>
		/// <param name="lvlstruc">Level structure.</param>
		public GridCase (AScene scene, int newWidth, int newHeigth, int[,] lvlstruc) : base (scene)
		{

			width = newWidth;
			heigth = newHeigth;
			levelStructure = lvlstruc;
			caseTab = new GameCase[width * heigth];
			int count = 0;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < heigth; j++)
				{
					
					//Console.WriteLine (count);
					caseTab[count] = new GameCase(scene);
					scene.AddEntity(caseTab[count]);
					caseTab[count].Position = new Vector2(_position.X + caseTab[count].Size.X + caseTab[count].Size.X * 2 * i,
						_position.Y + caseTab[count].Size.Y + caseTab[count].Size.Y * 2 * j);

					//Creation case
					if(levelStructure != null){
						if (levelStructure [i, j] == 0) {
							this.caseTab [count].actualState = GameCase.e_state.GRAY;
						}else if(levelStructure [i, j] == 1){
							this.caseTab [count].actualState = GameCase.e_state.FACE;
						}else if(levelStructure [i, j] == 2){
							this.caseTab [count].actualState = GameCase.e_state.PILE;
						}else if(levelStructure [i, j] == 3){
							this.caseTab [count].actualState = GameCase.e_state.SPECIAL_FACE;
						}else if(levelStructure [i, j] == 4){
							this.caseTab [count].actualState = GameCase.e_state.SPECIAL_PILE;
						}
							
					}

					this.caseTab [count].coordonnee = new Vector2 (i, j);

					count++;

				}
			}
				
		}
			

		public override void Initialize()
		{
			base.Initialize ();
		}

		public override void LoadContent()
		{
			base.LoadContent ();
		}

		/// <summary>
		/// Gets the size of the case.
		/// </summary>
		/// <returns>The case size.</returns>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public Vector2 GetCaseSize(int x, int y)
		{
			int count = 0;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < heigth; j++)
				{
					if (x == i && j == y)
						return caseTab[count].Position;
					count++;
				}
			}
			return Vector2.Zero;
		}

		/// <summary>
		/// Gets the size of the case.
		/// </summary>
		/// <returns>The case size.</returns>
		/// <param name="caseNumber">Case number.</param>
		public Vector2 GetCaseSize(int caseNumber)
		{
			int count = 0;
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < heigth; j++)
				{
					if (count == caseNumber)
						return caseTab[count].Position;
					count++;
				}
			}
			return Vector2.Zero;
		}

		public override void Update(GameTime gameTime)
		{
			Position = new Vector2(3f, 3f);

			//victory verification
			if (checkLineSameColor ()) {
				Console.WriteLine("Gagne!!!");
			}
			base.Update (gameTime);
		}

		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}

		/// <summary>
		/// Checks the color of each line.
		/// </summary>
		/// <returns><c>true</c>, return true, <c>false</c> return false.</returns>
		public bool checkLineSameColor() {
			e_state check;

			//browse grid verticaly
			for (int i = 0; i < heigth; i++) {

				//Each loop check is initialise to Gray
				check = e_state.GRAY;

				//Browse grid horizontaly
				for (int j = i; j < caseTab.Length; j+=width ) {

					if (caseTab [j].actualState != GameCase.e_state.GRAY) {

						//check if each have the same color
						if (check == e_state.GRAY) {
							check = (e_state)caseTab [j].actualState;
						} else if (check != (e_state)caseTab [j].actualState){
							//Console.WriteLine ("Perdu");
							return false;
						}
							
						//Console.WriteLine("Ligne : " + i + " | Case :" + j);
					}

				}

			}
			//Console.WriteLine ("C'est gagne");

			return true;
		}



	}
}

