import { Component } from "react";
import './Table.css'

export class PlayerStatisticsTable extends Component {
    render(){
        return (
            <div>
                <table className="styled-table">
                    <thead>
                    <tr>
                        <th>Player</th>
                        <th>Dribbles</th>
                        <th>Shots Taken</th>
                        <th>Shots Accuracy</th>
                        <th>Shots On Target</th>
                        <th>Pass Accuracy</th>
                        <th>Goals</th>
                        <th>Fouls</th>
                        <th>Player Position</th>
                    </tr>
                    </thead>
                    <tbody>
                    {this.props.statistics.length > 0 ? (this.props.statistics.map(player => (
                        <tr key={player.id}>
                            <td>{player.playerName}</td>
                            <td>{player.dribbles ? player.dribbles : 'N/A'}</td>
                            <td>{player.shotsTaken ? player.shotsTaken : 'N/A'}</td>
                            <td>{player.shotAccuracy ? (player.shotAccuracy * 100) + '%' : 'N/A'}</td>
                            <td>{player.shotsOnTarget ? player.shotsOnTarget : 'N/A'}</td>
                            <td>{player.passAccuracy ? (player.passAccuracy * 100) + '%' : 'N/A'}</td>
                            <td>{player.goalsCount}</td>
                            <td>{player.foulsCount}</td>
                            <td>{player.playerPosition ? player.playerPosition : 'N/A'}</td>
                        </tr>
                    ))
                    ) : "No statistics found"}
                    </tbody>
                </table>
            </div>
        )
    }
}