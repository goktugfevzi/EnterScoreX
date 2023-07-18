var x = 0,
    container = $('.slider-game-time'),
    items = container.find('li'),
    containerHeight = 0,
    numberVisible = 5,
    intervalSec = 5600;

if(!container.find('li:first').hasClass("active")){
  container.find('li:first').addClass("active");
}

items.each(function(){
  if(x < numberVisible){
    containerHeight = containerHeight + $(this).outerHeight();
    x++;
  }
});

container.css({ height: containerHeight, overflow: "hidden" });
  
function vertCycle() {
  var firstItem = container.find('li.active').html();
    
  container.append('<li>'+firstItem+'</li>');
  firstItem = '';
  container.find('li.active').animate({ marginTop: "-50px" }, 600, function(){  $(this).remove(); container.find('li:first').addClass("active"); });
}

if(intervalSec < 700){
  intervalSec = 700;
}

var init = setInterval("vertCycle()",intervalSec);

container.hover(function(){
  clearInterval(init);
}, function(){
  init = setInterval("vertCycle()",intervalSec);
});