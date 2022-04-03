<?php
  $user = 'root';
  $pass = '';
  $db = 'vacations';

  $conn = new mysqli('localhost', $user, $pass, $db) or die("unable to connect to database");

  $sql = "SELECT * FROM destinations";
  $result = $conn->query($sql);

  if ($result->num_rows > 0) {
    $array = array();

    while($row = $result->fetch_assoc()) {
      $obj = array(
        'id' => $row["id"], 
        'city' => $row["city"],
        'country' => $row['country'],
        'description' => $row['descriptions'],
        'tourists_target' => $row['tourists_target'],
        'estimated_cost' => $row['estimated_cost'],
      );

      $json_obj = json_encode($obj);
      array_push($array, $obj);
    }

    echo json_encode($array);
  } else {
    echo "0 results";
  }

  $conn->close();
?>