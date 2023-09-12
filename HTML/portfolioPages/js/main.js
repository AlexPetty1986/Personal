function closeInfo(type)
{
    buttonType = document.getElementsByClassName(type);
    console.log(buttonType.length)
    for(let i = 0; i < buttonType.length; i++)
    {
        if(buttonType[i].ariaExpanded == "true")
        {
            buttonType[i].click();
            console.log("button clicked");
        }
    }
}