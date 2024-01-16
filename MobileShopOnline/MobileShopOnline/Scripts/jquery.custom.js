$(document).ready(function () {
   $(".sub-image img").hover(function () {
      var imgPath = $(this).attr('src');
      $("#main_details-image").attr('src', imgPath);
   })

   // start-rating

   $("#1-star").mouseover(function () {
      $("#1-star").css('color', 'gold');
   })
   $("#1-star").mouseout(function () {
      $("#1-star").css('color', 'rgb(212, 212, 212)');
   })

   $("#2-star").mouseover(function () {
      $("#1-star").css('color', 'gold');
      $("#2-star").css('color', 'gold');
   })

   $("#2-star").mouseout(function () {
      $("#1-star").css('color', 'rgb(212, 212, 212)');
      $("#2-star").css('color', 'rgb(212, 212, 212)');
   })

   $("#3-star").mouseover(function () {
      $("#1-star").css('color', 'gold');
      $("#2-star").css('color', 'gold');
      $("#3-star").css('color', 'gold');
   })

   $("#3-star").mouseout(function () {
      $("#1-star").css('color', 'rgb(212, 212, 212)');
      $("#2-star").css('color', 'rgb(212, 212, 212)');
      $("#3-star").css('color', 'rgb(212, 212, 212)');
   })

   $("#4-star").mouseover(function () {
      $("#1-star").css('color', 'gold');
      $("#2-star").css('color', 'gold');
      $("#3-star").css('color', 'gold');
      $("#4-star").css('color', 'gold');

   })

   $("#4-star").mouseout(function () {
      $("#1-star").css('color', 'rgb(212, 212, 212)');
      $("#2-star").css('color', 'rgb(212, 212, 212)');
      $("#3-star").css('color', 'rgb(212, 212, 212)');
      $("#4-star").css('color', 'rgb(212, 212, 212)');
   })


   $("#5-star").mouseover(function () {
      $("#1-star").css('color', 'gold');
      $("#2-star").css('color', 'gold');
      $("#3-star").css('color', 'gold');
      $("#4-star").css('color', 'gold');
      $("#5-star").css('color', 'gold');


   })

   $("#5-star").mouseout(function () {
      $("#1-star").css('color', 'rgb(212, 212, 212)');
      $("#2-star").css('color', 'rgb(212, 212, 212)');
      $("#3-star").css('color', 'rgb(212, 212, 212)');
      $("#4-star").css('color', 'rgb(212, 212, 212)');
      $("#5-star").css('color', 'rgb(212, 212, 212)');
   })
   

   //submit ko load trang

   //$('#rating-comment-form').submit(function(event) {
   //   $.ajax({
   //       method: $(this).attr('method'),
   //       url: $(this).attr('action'),
   //       data: $(this).serialize(),
   //   }).done(function(response) {
   //   });
   //   event.preventDefault(); 
   //});

})

