<?php
  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");
  echo 'connect </br>';

  $sql = "SELECT * FROM destinations";
  $result = $conn->query($sql);

  if ($result->num_rows > 0) {
    while($row = $result->fetch_assoc()) {
      echo "id: " . $row["id"]. " - city: " . $row["city"]. " " . " - country: " . $row["country"]. "<br>";
    }
  } else {
    echo "0 results";
  }

  $conn->close()
?>