import React, { Component } from 'react';
import './Table.css'

export class MatchesTable extends Component {
  render() {
    return(
        <div>
            <table className="styled-table">
                <thead>
                <tr>
                <th>Start time</th>
                <th>Home team</th>
                <th>Score</th>
                <th>Away Team</th>
                </tr>
                </thead>
                <tbody>
                {this.props.matchesData.length > 0 ? (this.props.matchesData.map(match => (
                    <tr key={match.id} onClick={() => this.props.matchClickedHandler(match.id)}>
                    <td>{match.startTime}</td>
                    <td>{match.homeTeam.name}</td>
                    <td>{match.homeTeamGoalsCount} : {match.awayTeamGoalsCount}</td>
                    <td>{match.awayTeam.name}</td>
                    </tr>
                ))) : "No matches found"}
                </tbody>
            </table>
        </div>
    )
  }
}