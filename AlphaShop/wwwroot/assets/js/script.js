
document.addEventListener('DOMContentLoaded',function(){
    const closeButton = document.getElementById('ev');
    const closeButton1 = document.getElementById('ev1');
    const closeButton2 = document.getElementById('ev2');
    btncp.addEventListener('click',function(){
            modal1.style.display='flex';
            
    });
    closeButton.addEventListener('click', function() {
        modal1.style.display = 'none'; 
      });
    document.addEventListener('click',function (event) {
        if(event.target != c && !c1.contains(event.target))
        {
            modal1.style.display="none";
        }
    });
    btncs.addEventListener('click',function(){  
        modal2.style.display='flex';
    });
    closeButton1.addEventListener('click', function() {
        modal2.style.display = 'none'; 
      });
    btnce.addEventListener('click',function(){  
        modal3.style.display='flex';
    });
    closeButton2.addEventListener('click', function() {
        modal3.style.display = 'none'; 
    });  
});


  