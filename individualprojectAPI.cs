public class PictureChanger
{

    /// </summary>
    /// <param name="OriginalImage"> the original photo uploaded to the server
    /// <returns>the image in the proper format for editing
    //[Route("/PictureChanger/UploadImage/1234")]
    [HttpPost]
    public IHttpActionResult UploadImage([FromBody] file originalImage, [FromUri] imageID)
    {
	    //convert the file uploaded from the user to the appropriate format for editing
	    //The imageID will always be associated with the image as it changes
        return this.Success(PictureChanger);
    }

    /// <summary>
    /// Create a queue of manipulations
    /// </summary>
    /// <param name="change">the specific change the user wants to make to the picture. Either
    /// a horizontal rotation, vert. rotation, degree shift, black/white conversion,  resize, rotate left or right,
    /// or create a thumbnail
    [Route("/PictureChanger/addChange")]
    [HttpPost]
    public IHttpActionResult addChange([FromBody] ManipulationObject change, int imageID)
    {
		//add the manipulation to the queue associated with the imageID to be processed in the order
		//received
        return this.Success(null);
    }

    /// <summary>
    /// Get a change object from the queue
    /// </summary>
    /// <param name="change">the next change in the queue
    /// <param name="imageID">identifier associated with the queue and the picture to be changed
    /// <returns>json object containing the imageID along with the next change in the queue
    [Route("/PictureChanger/getChange")]
    [HttpGet]
    public IHttpActionResult getChange([FromBody] ManipulationObject change, int imageID)
    {
        //Retrieve the next change in the queue associate with the imageID
        //Update the queue appropriately
        return this.Success({ManipulationObject change, int imageID});

    }

    /// <summary>
    /// get the final picture from the server
    /// </summary>
    /// <param name="imageID">the imageID associated with the picture desired to be retrieved
    /// such as moveSpeed, playerLives, etc.</param>
    /// <returns>The initial game state object</returns>
    [Route("/ImageChanger/getPicture")]
    [HttpGet]
    public IHttpActionResult getPicture(int imageID)
    {
        //get the final picture after all changes have been made.
        return this.Success(Image);

    }

    /// <summary>
    /// Delete the picture altogether
    /// </summary>
    /// <param name="imageID">the imageID to find and delete everything associate with that one ID
    [Route("/ImageChanger/deleteImage")]
    [HttpGet]
    public IHttpActionResult deleteImage(([FromUri] int imageID)
    {
        //Delete the image
			return this.Success(null);
    }
}
