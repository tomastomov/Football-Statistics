import logo from './logo.svg';
import './App.css';
import { MatchesTable } from './MatchesTable';
import { Component } from 'react';
import { PlayersSelectList, TeamSelectList } from './TeamSelectList';
import { PlayerStatisticsTable } from './PlayerStatisticsTable';
import { LeaguesSelectList } from './LeaguesSelectList';
import Calendar from 'short-react-calendar';
import { Container } from 'react-bootstrap';
import { Col, Row } from "react-bootstrap";
import { get } from './fetcher.js';

class App extends Component {
  constructor(props) {
    super(props);
    this.state = { matchesData: [], players: [], selectedMatchId: -1, selectedLeagueId: -1, selecetedDate: -1, playersStatistics: [], teamsForSelectedMatch: [], leagues: [], baseUrl: 'https://localhost:44383' }
    this.matchClickedHandler = this.matchClickedHandler.bind(this);
    this.teamChangedHandler = this.teamChangedHandler.bind(this);
    this.leagueChangedHandler = this.leagueChangedHandler.bind(this);
    this.onCalendarDateChanged = this.onCalendarDateChanged.bind(this);
  }
  componentDidMount() {
    this.fetchLeagues();
  }

  fetchMatches(leagueId, date) {
    get(`${this.state.baseUrl}/matches/${leagueId}/${date && date != -1 ? date : new Date().toUTCString()}`)
      .then(data => data.json())
      .then(data => this.setState({
        matchesData: data
      }))
  }

  matchClickedHandler(matchId) {
    this.setState({
      selectedMatchId: matchId
    });

    get(`${this.state.baseUrl}/teams?matchId=${matchId}`)
      .then(data => data.json())
      .then(data => {
        this.setState({
          teamsForSelectedMatch: data
        })
        return data;
      })
      .then(data => this.fetchPlayerStatistics(data[0].id));
  }

  leagueChangedHandler(e) {
    this.setState({
      playersStatistics: {},
      players: [],
      selectedMatchId: -1,
      selectedLeagueId: e.target.value
    })
    this.fetchMatches(e.target.value, this.state.selectedDate);
  }

  fetchLeagues() {
    get(`${this.state.baseUrl}/leagues`)
      .then(data => data.json())
      .then(data => {
        this.setState({
          leagues: data,
          selectedLeagueId: data[0].id
        });
        return data.length > 0 ? data[0].id : data;
      })
      .then(data => {
        if (data) {
          this.fetchMatches(data);
        }
      });
  }

  fetchPlayerStatistics(teamId) {
    get(`${this.state.baseUrl}/playerstatistics/${this.state.selectedMatchId}/${teamId}`)
      .then(data => data.json())
      .then(data => this.setState({
        playersStatistics: data
      }));
  }

  teamChangedHandler(e) {
    this.fetchPlayerStatistics(e.target.value);
  }

  onCalendarDateChanged(e) {
    this.setState({
      playersStatistics: [],
      selectedDate: e.toUTCString(),
      teamsForSelectedMatch: []
    })
    this.fetchMatches(this.state.selectedLeagueId, e.toUTCString());
  }

  render() {
    return (
      <Container>
        <Row className="centered-div">
          <Col>
            <Calendar onChange={this.onCalendarDateChanged}></Calendar>
          </Col>
        </Row>
        <Row>
          <Col className="left-aligned-div">
            <LeaguesSelectList leagueChangedHandler={this.leagueChangedHandler} leagues={this.state.leagues}></LeaguesSelectList>
          </Col>
          <Col className="right-aligned-div">
            <TeamSelectList teams={this.state.teamsForSelectedMatch} teamChangedHandler={this.teamChangedHandler}></TeamSelectList>
          </Col>
        </Row>
        <Row className="vertical-div">
          <Col>
            <MatchesTable matchesData={this.state.matchesData} matchClickedHandler={this.matchClickedHandler} ></MatchesTable>
          </Col>
          <Col>
            <PlayerStatisticsTable statistics={this.state.playersStatistics}></PlayerStatisticsTable>
          </Col>
        </Row>
      </Container>
    )
  }
}

export default App;
