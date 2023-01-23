// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
	public class StageTests
    {
		[Test]
	    public void CheckIfInitialisingTheCtorInitializesTheCollections()
	    {
			Stage stage = new Stage();
			Assert.IsNotNull(stage.Performers);
		}

		[Test]
		public void CheckIfAddingAPerformerWorks()
		{
			Stage stage = new Stage();
			Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
			Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Boby", "Bobster", 17)));
			Performer performer = new Performer("Bobby", "Nobby", 20);
			stage.AddPerformer(performer);
			Assert.AreEqual(1, stage.Performers.Count);
			Assert.True(stage.Performers.Any(x => x == performer));

		}

		[Test]
		public void CheckIfAddingASongWorks()
		{
			Stage stage = new Stage();
			Song song = new Song("TimeFlies", new TimeSpan(0, 0, 30));
			Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
			Assert.Throws<ArgumentException>(() => stage.AddSong(song));

		}

		[Test]
		public void CheckIfAddingASongToPerformerWorks()
		{
			Stage stage = new Stage();
			Song song = new Song("TimeFlies", new TimeSpan(0, 1, 30));
			Performer performer = new Performer("Bobby", "Nobby", 20);
			stage.AddSong(song);
			stage.AddPerformer(performer);
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Bob"));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Nob", null));
			Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, null));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer(song.Name, "test"));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("test", performer.FullName));
			Assert.Throws<ArgumentException>(() => stage.AddSongToPerformer("test", "test2"));
			
			string result = stage.AddSongToPerformer(song.Name, performer.FullName);
			Assert.True(performer.SongList.Contains(song));
			Assert.AreEqual($"{song} will be performed by {performer}", result);
		}

		[Test]
		public void CheckIfPlaingASongWorks()
        {
			Stage stage = new Stage();
			Song song = new Song("TimeFlies", new TimeSpan(0, 1, 30));
			Performer performer = new Performer("Bobby", "Nobby", 20);
			stage.AddSong(song);
			stage.AddPerformer(performer);
			stage.AddSongToPerformer(song.Name, performer.FullName);

			string result = stage.Play();
			Assert.AreEqual($"{stage.Performers.Count} performers played {stage.Performers.Sum(x => x.SongList.Count)} songs", result);

		}

	}
}