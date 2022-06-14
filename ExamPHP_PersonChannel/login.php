<?php
    session_start();
	  require_once "configuration.php";
    $_SESSION['myUser']= $_GET["username"];
    $myUser = $_SESSION['myUser'];

    ?>
 <html>

 <body>

     Welcome <?php echo $myUser; ?><br>
     <br>
     <br>

     <p>Your channel list</p>
     
<?php $myUser =$_SESSION['myUser'];
$str = "SELECT * from channels where subscribers like '%".$myUser."%'";
//  echo $str;
$result = mysqli_query($connection, $str);

//echo "<html><body>";
echo "<table border='1'><tr><th>Name</th><th>Description</th><th>Subscribers</th></tr>";
while($row = mysqli_fetch_array($result) ){
    echo "<tr>";
    echo "<td>" . $row['name'] . "</td>";
    echo "<td>" . $row['description'] . "</td>";
    echo "<td>" . $row['subscribers'] . "</td>";
    echo "</tr>";
}
echo "</table>";
//echo "</body></html>";
mysqli_close($connection);
?>
<br><br>


     <button onclick="window.location.href='ownedChannels.html'"> Show the owned by someone channels</button>
     <br>
     <br>
     <form action="addSubscriber.php" method="get">
            Name of the channel: <input type="text" name="cname" required><br>
            <input type="submit">
</form>
     
    

 </body>

 </html>