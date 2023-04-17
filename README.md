# ScrollToDemo
ScrollTo Demo is a simple .Net Maui App for demonstrating simple behaviors such as 
the ScrollView's ScrollToAsync functionality. It also is meant to demo other features
such as Tooltips on Label elements ( which doesn't work on Andoid) and how to set a
Label element's IsVisible property via Styles.

## Files
The project consists of a MainPage and two target pages, Paper000 and Paper001. 
Both pages have the same content but are structured slightly differently to 
test different functionality. The Main page has a checkbox that sets a boolean 
value on the ViewModel that determines if the IsVisible style on the Label's
used to provide a ReferenceId are true or false.

### Paper000 ScrollToAsync Behaivor Observed
On Windows the ScrollToAsync using Paper000 works as expected. On Android it does not work at all.
This has been filed as bug ([#14594](https://github.com/dotnet/maui/issues/14594)).