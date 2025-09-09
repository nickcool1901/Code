<?php
header("Content-Type: application/xml; charset=utf-8");

$dsn = "mysql:host=localhost;dbname=hockey_championship;charset=utf8";
$username = "root";
$password = "";

try {
    $pdo = new PDO($dsn, $username, $password, [
        PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION
    ]);

    $query = "SELECT g.game_date, g.game_time, 
                     t1.name AS team1_name, t1.country AS team1_country, t1.coach AS team1_coach,
                     t2.name AS team2_name, t2.country AS team2_country, t2.coach AS team2_coach,
                     a.name AS arena_name, a.city AS arena_city
              FROM games g
              JOIN teams t1 ON g.team1_id = t1.id
              JOIN teams t2 ON g.team2_id = t2.id
              JOIN arenas a ON g.arena_id = a.id
              ORDER BY g.game_date, g.game_time";
    
    $stmt = $pdo->query($query);

    $dom = new DOMDocument("1.0", "UTF-8");
    $dom->formatOutput = true;

    $root = $dom->createElement("schedule");
    $dom->appendChild($root);

    while ($row = $stmt->fetch(PDO::FETCH_ASSOC)) {
        $game = $dom->createElement("game");

        $game->appendChild($dom->createElement("date", $row["game_date"]));
        $game->appendChild($dom->createElement("time", $row["game_time"]));

        $arena = $dom->createElement("arena");
        $arena->appendChild($dom->createElement("name", $row["arena_name"]));
        $arena->appendChild($dom->createElement("city", $row["arena_city"]));
        $game->appendChild($arena);

        $team1 = $dom->createElement("team");
        $team1->appendChild($dom->createElement("name", $row["team1_name"]));
        $team1->appendChild($dom->createElement("country", $row["team1_country"]));
        $team1->appendChild($dom->createElement("coach", $row["team1_coach"]));
        $game->appendChild($team1);

        $team2 = $dom->createElement("team");
        $team2->appendChild($dom->createElement("name", $row["team2_name"]));
        $team2->appendChild($dom->createElement("country", $row["team2_country"]));
        $team2->appendChild($dom->createElement("coach", $row["team2_coach"]));
        $game->appendChild($team2);

        $root->appendChild($game);
    }
    
    $xmlString = $dom->saveXML();

    $file_path = "1.md.tabula.xml";
    file_put_contents($file_path, $xmlString);

    echo "XML fails saglabāts kā $file_path";

} catch (PDOException $e) {
    echo "Error: " . $e->getMessage();
}
?>
